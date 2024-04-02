using System;
using Class_card_extern;
using Class_number_external;
using Class_suit_external;

class Principal{
    static void Main(){
        List<Card> deck = GenerateDeck();
        Shuffle(deck);
        foreach (Card card in deck){
            Console.WriteLine(card);
        }
    }

    public static List<Card> GenerateDeck(){
        List<Card> deck = new List<Card>();
        Random rng = new Random();
        foreach (Numbers number in Enum.GetValues(typeof(Numbers))){
            foreach (Suits suit in Enum.GetValues(typeof(Suits))){
                Card card = new Card(number, suit);
                int position = rng.Next(deck.Count + 1);
                deck.Insert(position, card);
            }
        }
        return deck;
    }

    public static void Shuffle<T>(IList<T> list){
        Random rng = new Random();
        int n = list.Count;
        while (n > 1){
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}