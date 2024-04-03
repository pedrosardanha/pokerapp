using System;
using Class_card_extern;
using Class_rank_external;
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
        
        
        //Gera o deck de cartas, embaralha e gera o dicionário de cartas

        List<Card> hand = null;
        do{ 
            Dictionary<string, Card> allcards = [];
            List<Card> deck = GenerateDeck(out allcards);

            // Adiciona cartas à mão
            hand = deck.GetRange(0, 2);
            deck.RemoveRange(0, 2);

            // Adiciona cartas ao centro e à mão
            List<Card> center = deck.GetRange(0, 5);
            deck.RemoveRange(0, 5);

            hand = Pair(center, hand);
        }while(hand == null);
        WriteList(hand);
    }



// Gera deck já embralhado
    public static List<Card> GenerateDeck(out Dictionary<string, Card> allcards){
        List<Card> deck = [];
        allcards = [];
        Random rng = new();
        foreach (Rank number in Enum.GetValues(typeof(Rank))){
            foreach (Suits suit in Enum.GetValues(typeof(Suits))){
                Card card = new(number, suit);
                int position = rng.Next(deck.Count + 1);
                deck.Insert(position, card);
                allcards.Add(card.ToString(), card);
            }
        }
        return deck;
    }




    public static void WriteList(List<Card> list){
        foreach (Card card in list){
            Console.WriteLine(card);
        }
    }

    

    public static void pullCard(){

    }


    public static List<Card> Straight(List<Card> board, List<Card> cards)
    {
        cards.AddRange(board);
        cards.Sort((a, b) => b.number.CompareTo(a.number));

        for (int i = 0; i < cards.Count - 4; i++)
        {
            Card previous = cards[i];
            List<Card> straight = new List<Card> { previous };

            for (int j = i + 1; j < cards.Count; j++)
            {
                Card posterior = cards[j];

                if ((int)previous.number == (int)posterior.number + 1)
                {
                    straight.Add(posterior);
                }else{
                    break;
                }

                if (straight.Count == 5)
                {
                    return straight;
                }

                previous = posterior;
            }
        }

        return null;
    }

    public static List<Card> Flush(List<Card> board, List<Card> cards)
    {
        cards.AddRange(board);
        cards.Sort((a, b) => b.number.CompareTo(a.number));

        foreach (Suits suit in Enum.GetValues(typeof(Suits)))
        {
            List<Card> suitedCards = new List<Card>();

            foreach (Card card in cards)
            {
                if (card.suit == suit)
                {
                    suitedCards.Add(card);
                }

                if (suitedCards.Count == 5)
                {
                    return suitedCards;
                }
            }
        }

        return null;
    }

    public static List<Card> Pair(List<Card> board, List<Card> cards)
    {
        cards.AddRange(board);

        Dictionary<Rank, List<Card>> pairs = new Dictionary<Rank, List<Card>>();

        foreach (Card card in cards)
        {
            if (pairs.ContainsKey(card.number))
            {
                pairs[card.number].Add(card);
            }
            else
            {
                pairs[card.number] = new List<Card> { card };
            }
        }

        List<List<Card>> pairList = new List<List<Card>>(pairs.Values);
        pairList.Sort((a, b) => a.Count != b.Count ? b.Count.CompareTo(a.Count) : b[0].number.CompareTo(a[0].number));

        return pairList[0];
    }

}