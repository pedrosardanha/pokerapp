using System;
using Class_card_extern;
using Class_number_external;
using Class_suit_external;

class Principal{
    // Execução principal
    static void Main(){
        // Dictionary<string, int> count = [];
        

        // int i = 0;
        // while( i < 1000000){
        //     List<Card> deck = GenerateDeck();
        //     string key = deck[26].ToString();

        //     if (count.ContainsKey(key)){
        //         count[key]++;
        //     } else {
        //         count.Add(key,1);
        //     }
        //     i++;
        // }

        // foreach (KeyValuePair<string, int> entry in count){
        //     Console.WriteLine($"Chave: {entry.Key}, Valor: {entry.Value/1000000.0}");
        // }
        
        //Gera o deck de cartas e embaralha
        List<Card> deck = GenerateDeck();

        // Adiciona cartas à mão
        List<Card> hand = deck.GetRange(0, 2);
        deck.RemoveRange(0, 2);

        // Adiciona cartas ao centro e à mão
        List<Card> center = deck.GetRange(0, 5);
        hand.AddRange(center.GetRange(0, 5));
        deck.RemoveRange(0, 5);

        deck.Sort();
        
        Console.WriteLine("Mão:");
        WriteList(hand);
        Console.WriteLine("\nMesa:");
        WriteList(center);
        Console.WriteLine("\nBaralho:");
        WriteList(deck);
        
    }

// Gera deck já embralhado
    public static List<Card> GenerateDeck(){
        List<Card> deck = [];
        Random rng = new();
        foreach (Numbers number in Enum.GetValues(typeof(Numbers))){
            foreach (Suits suit in Enum.GetValues(typeof(Suits))){
                Card card = new(number, suit);
                int position = rng.Next(deck.Count + 1);
                deck.Insert(position, card);
            }
        }
        return deck;
    }

    public static void WriteList(List<Card> list){
        foreach (Card card in list){
            Console.WriteLine(card);
        }
    }
}