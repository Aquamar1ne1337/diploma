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
    
    public partial class Задание
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Задание()
        {
            this.Подзадача = new HashSet<Подзадача>();
            this.Распределение = new HashSet<Распределение>();
        }
    
        public int id_задания { get; set; }
        public int id_клиента { get; set; }
        public string Название { get; set; }
        public string Описание { get; set; }
        public System.DateTime Дата_создания { get; set; }
        public System.DateTime Крайний_срок { get; set; }
        public Nullable<int> id_статуса { get; set; }
    
        public virtual Клиент Клиент { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Подзадача> Подзадача { get; set; }
        public virtual Статус Статус { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Распределение> Распределение { get; set; }
    }
}
