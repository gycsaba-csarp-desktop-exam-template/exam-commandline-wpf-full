namespace Kreta.ExceptionHandler
{
    public class APIModelError
    {
        string FieldName { get; set; }
        string Message { get; set; }

        public APIModelError(string fieldName, string message)
        {
            FieldName = fieldName;
            Message = message;
        }


    }
}
