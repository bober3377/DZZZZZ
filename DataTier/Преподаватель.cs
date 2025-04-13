

namespace DataTier
{
    public class Преподаватель
    {
        public string ФИО { get; set; }
        public string Группа { get; set; }
        public int Курс { get; set; }
        public int КоличествоЗадолженностей { get; set; }

        public override string ToString()
        {
            return $"{ФИО} ({Группа}, курс {Курс}) - задолженностей: {КоличествоЗадолженностей}";
        }
    }
}
