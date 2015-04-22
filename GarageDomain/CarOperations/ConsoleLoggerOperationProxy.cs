using VotiroGarage;

namespace GarageDomain.CarOperations
{
    public class ConsoleLoggerOperationProxy : CarOperationBase
    {
        private readonly IGarageLog _logger = new GarageLogger(); //in real life scenerio it will be injected
        private readonly CarOperationBase _innerOperation;

        public ConsoleLoggerOperationProxy(CarOperationBase innerOperation)
        {
            _innerOperation = innerOperation;
        }

        public override void RunOperation()
        {
            _logger.Log(_innerOperation.PreExecutionMessage());

            _innerOperation.RunOperation();

            _logger.Log(_innerOperation.PostExecutionMessage());
        }
    }
}