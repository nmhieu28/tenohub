namespace HNM.Core.Domain.Entities;

public interface IHasConcurrencyStamp
{ 
    string ConcurrencyStamp { get; set; }
}