//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Diploma
{
    using System;
    using System.Collections.Generic;
    
    public partial class Клиент
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Клиент()
        {
            this.Задание = new HashSet<Задание>();
        }
    
        public int id_клиента { get; set; }
        public string Имя { get; set; }
        public string Электронная_почта { get; set; }
        public System.DateTime Дата_регистрации { get; set; }
        public string Телефон { get; set; }
        public string Город { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Задание> Задание { get; set; }
    }
}
