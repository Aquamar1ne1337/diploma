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
    
    public partial class Распределение
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Распределение()
        {
            this.Заметка = new HashSet<Заметка>();
        }
    
        public int id_распределения { get; set; }
        public int id_пользователя { get; set; }
        public int id_задания { get; set; }
        public System.DateTime Дата_распределения { get; set; }
    
        public virtual Задание Задание { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Заметка> Заметка { get; set; }
        public virtual Пользователь Пользователь { get; set; }
    }
}
