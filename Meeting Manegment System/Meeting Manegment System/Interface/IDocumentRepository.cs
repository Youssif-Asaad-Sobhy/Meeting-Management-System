using Meeting_Manegment_System.Models;

namespace Meeting_Manegment_System.Interface
{
    public interface IDocumentRepository
    {
        WordDocument GetFileById(int id);
        bool Add(WordDocument wordDocument);
        bool Update(WordDocument wordDocument);
        bool Delete(WordDocument wordDocument);
        bool Save();
    }
}