using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Cir.Repository
{
    public class DamagesSpecification : Specification
    {
        private readonly bool shouldHaveDamages;
        public DamagesSpecification(bool shouldHaveDamages)
        {
            this.shouldHaveDamages = shouldHaveDamages;
        }
        public override Expression<Func<JObject, bool>> ToExpression()
        {
            return cir =>
                (cir != null) &&
                (cir.Type == JTokenType.Object) &&
                (cir["cirSubmissionData"] != null) &&
                (cir["cirSubmissionData"].Type == JTokenType.Object) &&
                (cir["cirSubmissionData"]["data"] != null) &&
                (cir["cirSubmissionData"]["data"].Type == JTokenType.Object) &&
                (cir["cirSubmissionData"]["data"]["imagecomponentKey"] != null) &&
                (cir["cirSubmissionData"]["data"]["imagecomponentKey"].Type == JTokenType.Object) &&
                (cir["cirSubmissionData"]["data"]["imagecomponentKey"]["sections"] != null) &&
                (cir["cirSubmissionData"]["data"]["imagecomponentKey"]["sections"].Type == JTokenType.Object) &&
                (shouldHaveDamages == HasErrorInSections((JObject)cir["cirSubmissionData"]["data"]["imagecomponentKey"]["sections"]));
        }

        private bool HasErrorInSections(JObject sections)
        {
            for (int i = 1; i <= 12; ++i)
            {
                if ((sections[$"section{i}"] != null) &&
                    (sections[$"section{i}"].Type == JTokenType.Object) &&
                    (sections[$"section{i}"]["images"] != null) &&
                    (sections[$"section{i}"]["images"].Type == JTokenType.Array) &&
                    HasErrorInImages(((JArray)sections[$"section{i}"]["images"])))
                {
                    return true;
                }
            }
            return false;
        }

        private bool HasErrorInImages(JArray images)
        {
            foreach (var image in images)
            {
                if ((image["damageSeverity"] != null) &&
                    (image["damageSeverity"].Type == JTokenType.Integer) &&
                    (image["damageSeverity"].Value<int>() > 0))
                {
                    return true;
                }

            }
            return false;
        }

        public override string ToString()
        {
            return $"DamagesSpecification({shouldHaveDamages})";
        }
    }
}
