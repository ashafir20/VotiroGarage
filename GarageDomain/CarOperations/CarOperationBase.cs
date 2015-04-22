namespace GarageDomain.CarOperations
{
    public abstract class CarOperationBase
    {
        protected string OperationDescription { private get; set; }
        protected Car Car { get; set; }
        public abstract void RunOperation();
        public virtual string PreExecutionMessage()
        {
            return string.Format("Before running operation {0}: Car: {1}", OperationDescription, Car);
        }

        public virtual string PostExecutionMessage()
        {
            return string.Format("After running operation {0}: Car: {1}", OperationDescription, Car);
        }
    }
}
