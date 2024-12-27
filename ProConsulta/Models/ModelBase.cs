namespace ProConsulta.Models
{
    public abstract class ModelBase<T>
    {
        public virtual T Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Excluido { get; set; }
        public DateTime? DataExclusao { get; set; }
    }
}
