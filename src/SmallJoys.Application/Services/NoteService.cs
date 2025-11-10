using SmallJoys.Domain.Entities;
namespace SmallJoys.Application.Services;

public static class NoteService
{
    static List<Note> Notes { get; }
    static int nextId = 4;
    static NoteService()
    {

        Notes = [
            new()
            {
                Id = 1,
                Title = "First Note",
                Content = "This is first note form ASP.NET API!"
            },
              new()
              {
                Id = 2,
                Title = "The Art of Pizza",
                Content = "Pizza began in Naples as a humble dish for workers. Simple ingredients—dough, tomato, and cheese—created something timeless. Today, pizza has traveled the world, adapting to local tastes while keeping its essence intact.\nItalian pizza remains pure: thin crust, fresh mozzarella, and basil for balance. Every bite speaks of tradition and restraint. In contrast, American-style pizzas embrace abundance—thick crusts, layers of toppings, and bold flavors. Both reflect their cultures: one celebrates simplicity, the other creativity.\nWhat makes pizza special is its universality. It bridges age, class, and nationality. Whether eaten in a street market or a fine restaurant, it evokes the same comfort. It’s also endlessly adaptable—vegan, gluten-free, or wood-fired versions all share the same foundation.\nAt its core, pizza is about connection. It’s meant to be shared, sliced into equal parts, enjoyed in company. The best pizzas aren’t just well-cooked—they’re moments captured: laughter, conversation, and warmth."
              },
              new()
               {
                Id = 3,
                Title = "Land of Contrasts",
                Content = "Japan is a country where the past and the future coexist in perfect harmony. Ancient temples stand beside neon-lit skyscrapers, and centuries-old rituals unfold within one of the world’s most technologically advanced societies.\nTokyo represents the modern face of Japan—fast, efficient, and innovative. Trains arrive on time to the second, and convenience is engineered into daily life. Yet, a short journey from the capital reveals another side of the country: quiet shrines, tea houses, and landscapes that have inspired poets for generations.\nThe Japanese approach to life—rooted in mindfulness, respect, and precision—permeates everything from cuisine to craftsmanship. Meals are artful compositions, blending taste and aesthetics. Even the act of making tea or folding paper reflects a deep cultural philosophy: beauty lies in simplicity and attention.\nDespite modernization, Japan’s reverence for nature and tradition endures. The cherry blossom season, for instance, draws millions not just for its beauty but for its reminder of life’s impermanence. This awareness shapes a collective mindset of gratitude and humility.\nVisiting Japan is more than travel—it’s immersion into a culture that values both silence and innovation, both the fleeting and the eternal.."
              }
        ];
    }


    public static List<Note> GetAll() => Notes;

    public static Note? Get(int id) => Notes.FirstOrDefault(note => note.Id == id);

    public static void Add(Note note)
    {
        note.Id = nextId++;
        Notes.Add(note);
    }

    public static void Delete(int id)
    {
        var note = Get(id);
        if (note is null)
            return;

        Notes.Remove(note);
    }

    public static void Update(Note note)
    {
        var index = Notes.FindIndex(n => n.Id == note.Id);
        if (index == -1)
            return;

        Notes[index] = note;
    }
}
