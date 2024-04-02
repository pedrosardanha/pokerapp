using Class_number_external;
using Class_suit_external;

namespace Class_card_extern{
    public class Card{
        private Numbers number;
        private Suits suit;

        public Card(Numbers number, Suits suit){
            this.number = number;
            this.suit = suit;
        }
        public override string ToString(){
            return $"{number} {suit}";
        }
    }
}