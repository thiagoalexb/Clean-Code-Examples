
namespace CleanCode.MagicNumbers
{
    #region Wrong
    public class MagicNumbersWrong
    {
        public void ApproveDocument(int status)
        {
            if (status == 1)
            {
                // ...
            }
            else if (status == 2)
            {
                // ...
            }
        }

        public void RejectDoument(string status)
        {
            switch (status)
            {
                case "1":
                    // ...
                    break;
                case "2":
                    // ...
                    break;
            }
        }
    }
    #endregion

    #region Right
    public class MagicNumbers
    {
        //it becomes clearer what each status is with an enumerator and can be used in more places
        public void ApproveDocument(DocumentStatus status)
        {
            if (status == DocumentStatus.Draft)
            {
                // ...
            }
            else if (status == DocumentStatus.Logded)
            {
                // ...
            }
        }

        public void RejectDocument(DocumentStatus status)
        {
            switch (status)
            {
                case DocumentStatus.Draft:
                    // ...
                    break;
                case DocumentStatus.Logded:
                    // ...
                    break;
            }
        }
    }

    public enum DocumentStatus //Enum always in the singular 
    {
        Draft = 1,
        Logded = 2
    }
    #endregion
}
