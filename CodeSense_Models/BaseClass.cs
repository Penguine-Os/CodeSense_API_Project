using System.ComponentModel;

namespace CodeSense_Models
{
    public abstract class BaseClass : IDataErrorInfo
    {
        public abstract string this[string columnName] { get; }

        public bool IsValid()
        {
            return string.IsNullOrWhiteSpace(Error);
        }

        public string Error
        {
            get
            {
                string errorMessage = "";

                foreach (var item in this.GetType().GetProperties())
                {
                    if (item.CanRead)
                    {

                        string error = this[item.Name];
                        if (!string.IsNullOrWhiteSpace(error))
                        {
                            errorMessage += error + Environment.NewLine;
                        }
                    }
                }
                return errorMessage;
            }
        }
    }

}
