using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace TaskManager.App
{
    public static class Extensions
    {
        public static Dictionary<string, List<string>> ToJson(this ModelStateDictionary modelStateDictionary)
        {
            Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
            
            foreach (var keyValuePair in modelStateDictionary)
            {
                List<string> errorMessages = new List<string>();
                
                foreach (ModelError modelError in keyValuePair.Value.Errors)
                {
                    errorMessages.Add(modelError.ErrorMessage);
                }
                
                errors.Add(keyValuePair.Key, errorMessages);
            }
            
            return errors;
        }
    }
}