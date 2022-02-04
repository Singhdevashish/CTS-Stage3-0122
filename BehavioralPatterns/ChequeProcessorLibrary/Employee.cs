namespace ChequeProcessorLibrary
{
    public abstract class Employee
    {
        public string Name { get; set; }
        public Employee(string name)
        {
            this.Name = name;
        }
        public abstract ChequeStatus ClearCheque(Cheque cheque);
    }
   

}
