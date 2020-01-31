using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoldDiggerApi
{
    class Turn
    {
        IEnumerable<Player> Players { get; set; }
        Player Winner { get; set; } = new NoPlayer();

        public Turn(IEnumerable<Player> players)
        {
            Players = players;
        }

        internal void Play()
        {
            SelectPlayCard();
            CompareCards();
            End();
        }

        void SelectPlayCard()
        {
            var players = Players.OrderBy(p => p.TurnTaking) as IEnumerable<Player>;

            // Let the first player choose a card as the ruling card.
            var firstPlayer = players.First();
            FirstPlayer(firstPlayer);

            // Let the other players choose their cards.
            players = players.Skip(1);
            foreach (var player in players)
            {
                OtherPlayers(player, firstPlayer.Current);
            }
        }

        void FirstPlayer(Player player)
        {
            var cards = player.Cards.Select(c => (Available: true, Card: c));
            var card = player.LetPlayerChooseCard(cards);
            player.IsFirstPlayer = true;
            player.Current = card;
        }

        void OtherPlayers(Player player, Card firstPlayerCard)
        {
            var matching = player.Cards.Where(c => c.Rank == Ranks.Jack || c.Suit == firstPlayerCard.Suit);   // Allow cards to play with.
            var cards = Enumerable.Empty<(bool, Card)>();

            // The player doesn't have any jacks or matching cards to the first player's selected card.
            if (matching.Count() == 0)
            {
                cards = player.Cards.Select(c => (Available: true, Card: c));
            }
            else
            {
                cards = player.Cards.Select(c => (Available: matching.Contains(c), Card: c));
            }

            var card = player.LetPlayerChooseCard(cards);
            player.Current = card;
        }

        void CompareCards()
        {
            var end = false;

            // Big gold digger.
            end = BigGoldDigger();
            if (end) return;

            // Gold digger.
            end = GoldDigger();
            if (end) return;

            // Highest card with the same suit.
            end = HighestCardSameSuit();
            if (end) return;

            // No other players´ cards could beat the first player.
            Winner = Players.First(p => p.IsFirstPlayer);
        }

        /// <summary>
        /// Check if any player has the big gold digger.
        /// </summary>
        /// <returns></returns>
        bool BigGoldDigger()
        {
            var ownsBigGoldDigger = Players.First(p => p.Current.IsBigGoldDigger);
            if (ownsBigGoldDigger != null)
            {
                Winner = ownsBigGoldDigger;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check if any player has a gold digger.
        /// </summary>
        /// <returns></returns>
        bool GoldDigger()
        {
            var end = false;

            // If first player has a gold digger.
            end = FirstPlayerWithGoldDigger();
            if (end) return true;

            // Second, third or forth player has gold diggers.
            var hasGoldDiggers = Players.Where(p => p.Current.IsGoldDigger);

            // There is only one player with a gold digger.
            if (hasGoldDiggers.Count() == 1)
            {
                Winner = hasGoldDiggers.First();
                return true;
            }
            // There are several players with gold diggers.
            else if (hasGoldDiggers.Count() > 1)
            {
                // The player with the matching gold digger to the select suit.
                end = GoldDiggerMatchingSuit(hasGoldDiggers);
                if (end) return true;

                // The player with the hight values gold digger.
                end = GolderDiggerMostValued(hasGoldDiggers);
                if (end) return true;
            }
            return false;
        }

        /// <summary>
        /// First player has a gold digger.
        /// </summary>
        /// <returns></returns>
        bool FirstPlayerWithGoldDigger()
        {
            if (Players.Any(p => p.IsFirstPlayer && p.Current.IsGoldDigger))
            {
                Winner = Players.First(p => p.IsFirstPlayer);
                return true;
            }
            return false;
        }

        /// <summary>
        /// One player has a gold digger matching the selected suit by the first player.
        /// </summary>
        /// <param name="hasGoldDiggers"></param>
        /// <returns></returns>
        bool GoldDiggerMatchingSuit(IEnumerable<Player> hasGoldDiggers)
        {
            var rulingSuit = Players.First(p => p.IsFirstPlayer).Current.Suit;
            var temp = hasGoldDiggers.First(p => p.Current.Suit == rulingSuit);
            if (temp != null)
            {
                Winner = temp;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Several player have gold diggers. Check the suit which is the "highest".
        /// </summary>
        /// <param name="hasGolderDiggers"></param>
        /// <returns></returns>
        bool GolderDiggerMostValued(IEnumerable<Player> hasGolderDiggers)
        {
            // Spades are set to the highest suit. The spades suit is set to zero in the enum. Please see Enum.Suits. 
            // Check the lowest value of the suit enum for the highest gold digger.

            var temp = hasGolderDiggers.Aggregate((p1, p2) => p1.Current.Suit < p2.Current.Suit ? p1 : p2);
            if (temp != null)
            {
                Winner = temp;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Card with most value with same suit as the first player.
        /// </summary>
        /// <returns></returns>
        bool HighestCardSameSuit()
        {
            var rulingSuit = Players.First(p => p.IsFirstPlayer).Current.Suit;
            var playersWithSuit = Players.Where(p => p.Current.Suit == rulingSuit);

            // No other player has a card with the same suit as the first player.
            if (playersWithSuit.Count() == 1)
            {
                Winner = playersWithSuit.First();
                return true;
            }
            // Several players (first player included) have a each a card with the suit as the first player.
            // Check which card is the highest and select the winner based on the height value.
            else if (playersWithSuit.Count() > 1)
            {
                var temp = playersWithSuit.Aggregate((p1, p2) => p1.Current.Rank > p2.Current.Rank ? p1 : p2);
                Winner = temp;
                return true;
            }
            return false;
        }

        void End()
        {

        }
    }
}
