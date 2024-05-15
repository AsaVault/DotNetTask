using AssessmentTask.Models;
using System.Data;
using System.Globalization;
using System.Reflection;

namespace AssessmentTask.Common
{
    public static class Mapping
    {
        public static TEntity Map<TEntity>(TEntity dr) where TEntity : class, new()
        {
            TEntity instanceToPopulate = new TEntity();
            PropertyInfo[] propertyInfos = typeof(TEntity).GetProperties
            (BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo pi in propertyInfos)
            {
                DataFieldAttribute[] datafieldAttributeArray = pi.GetCustomAttributes
                (typeof(DataFieldAttribute), false) as DataFieldAttribute[];
                if (datafieldAttributeArray != null && datafieldAttributeArray.Length == 1)
                {
                    DataFieldAttribute dfa = datafieldAttributeArray[0];
                    //object dbValue = dr[dfa.Name];
                    //if (dbValue != null)
                    //{
                    //    pi.SetValue(instanceToPopulate, Convert.ChangeType
                    //    (dbValue, pi.PropertyType, CultureInfo.InvariantCulture), null);
                    //}
                }
            }
            return instanceToPopulate;
        }

        public static CustomQuestion MapPersonalInfo(QuestionTemplateResponse dr)
        {


            if (dr.Name == Constant.Date || dr.Name == Constant.Number || dr.Name == Constant.Paragraph)
            {
                var dbValue = new SingleInput();
                dbValue.Name = dr.Id;
                dbValue.Id = dr.Id;
                dbValue.Option = dr.Question;
                dbValue.Label = dr.Question;

                if (dr.Name == Constant.Date)
                {
                    dbValue.Type = Constant.InputDate;
                }

                if (dr.Name == Constant.Number)
                {
                    dbValue.Type = Constant.InputNumber;
                }

                if (dr.Name == Constant.Paragraph)
                {
                    dbValue.Type = Constant.InputText;
                }
                return dbValue;
            }
            else if (dr.Name == Constant.YesNO)
            {
                var dbValue = new MultipleInput();
                dbValue.Name = dr.Name;
                dbValue.Id = dr.Id;
                dbValue.Type = Constant.InputRadio;
                dbValue.Label = dr.Question;
                dbValue.Options = new List<string> { "Yes", "No" };
                return dbValue;
            }
            else if (dr.Name == Constant.MultipleChoice)
            {
                var dbValue = new MultipleDropDown();
                dbValue.Name = dr.Name;
                dbValue.Id = dr.Id;
                dbValue.Label = dr.Question;
                dbValue.Options = dr.Choices;
                dbValue.Type = Constant.SelectMultiple;
                return dbValue;
            }
            else if (dr.Name == Constant.Dropdown)
            {
                var dbValue = new SingleDropDown();
                dbValue.Name = dr.Name;
                dbValue.Id = dr.Id;
                dbValue.Label = dr.Question;
                dbValue.Options = dr.Choices;
                dbValue.Type = Constant.SelectMultiple;
                return dbValue;
            }

            return default;
        }

        public static QuestionTemplateResponse MapQuestion(QuestionTemplateRequest dr)
        {

            var dbValue = new QuestionTemplateResponse();
            dbValue.Name = dr.Name;
            dbValue.Other = dr.Other;

            if (!dr.MaxChoiceAllowed)
            {
                dbValue.MaxChoiceAllowed = 0;
            }
            if (dr.Name == Constant.Date || dr.Name == Constant.Number || dr.Name == Constant.Paragraph)
            {

                if (dr.Name == Constant.Date)
                {
                    dbValue.Type = Constant.InputDate;
                }

                if (dr.Name == Constant.Number)
                {
                    dbValue.Type = Constant.InputNumber;
                }

                if (dr.Name == Constant.Paragraph)
                {
                    dbValue.Type = Constant.InputText;
                }
                return dbValue;
            }
            else if (dr.Name == Constant.YesNO)
            {
                dbValue.Name = dr.Name;
                dbValue.Type = Constant.InputRadio;
                return dbValue;
            }
            else if (dr.Name == Constant.MultipleChoice)
            {
                dbValue.Name = dr.Name;
                dbValue.Type = Constant.SelectMultiple;
                return dbValue;
            }
            else if (dr.Name == Constant.Dropdown)
            {
                dbValue.Name = dr.Name;
                dbValue.Type = Constant.SelectMultiple;
                return dbValue;
            }

            return default;
        }
    }
}
