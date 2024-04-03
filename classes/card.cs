using Class_rank_external;
using Class_suit_external;

namespace Class_card_extern{
    public class Card{
        public Rank number;
        public Suits suit;

        public Card(Rank number, Suits suit){
            this.number = number;
            this.suit = suit;
        }
        public override string ToString(){
            return $"{number} {suit}";
        }
    }
}