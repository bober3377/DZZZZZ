using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTier;

namespace LogicTier
{
    public class Университет
    {
        private List<Преподаватель> _преподаватели;

        public Университет(List<Преподаватель> преподаватели)
        {
            _преподаватели = преподаватели;
        }

        public Dictionary<string, int> СуммарныеЗадолженностиПоГруппам()
        {
            return _преподаватели
                .GroupBy(p => p.Группа)
                .ToDictionary(g => g.Key, g => g.Sum(p => p.КоличествоЗадолженностей));
        }

        public Dictionary<int, double> СредниеЗадолженностиПоКурсам()
        {
            return _преподаватели
                .GroupBy(p => p.Курс)
                .ToDictionary(g => g.Key, g => g.Average(p => p.КоличествоЗадолженностей));
        }

        public List<Преподаватель> СписокПреподавателей => _преподаватели;
    }
}
