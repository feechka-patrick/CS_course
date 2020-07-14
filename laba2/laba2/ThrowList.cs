using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace laba2
{
    public class ThrowList// : INotifyPropertyChanged // проверка на входые значения
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public string ObjectOfInfluence { get; set; }
        public string PrivacyPolicy { get; set; }
        public string Integrity { get; set; }
        public string Availability { get; set; }

        public ThrowList()
        {
            Id = "Идентификатор угрозы";
            Name = "Наименование угрозы";
            Description = "Описание угрозы";
            Source = "Источник угрозы";
            ObjectOfInfluence = "Объект воздействия";
            PrivacyPolicy = "Нарушение конфидентиальности";
            Integrity = "Нарушение целостности";
            Availability = "Нарушение доступности";
        }
        //public event PropertyChangedEventHandler PropertyChanged;
        //public void OnPropertyChanged([CallerMemberName]string prop = "")
        //{
        //    if (PropertyChanged != null)
        //        PropertyChanged(this, new PropertyChangedEventArgs(prop));
        //}
    }
}
