using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.CustWeb.ViewModels
{

    [Serializable]
    public class QuotationWizardViewModel
    {
        public int CurrentStepIndex { get; set; }
        public IList<IStepViewModel> Steps { get; set; }

        public Step1ViewModel Step1 { get; set; }
        public Step2ViewModel Step2 { get; set; }
        public Step3ViewModel Step3 { get; set; }

        public void Initialize()
        {
            Steps = typeof(IStepViewModel)
                .Assembly
                .GetTypes()
                .Where(t => !t.IsAbstract && typeof(IStepViewModel).IsAssignableFrom(t))
                .Select(t => (IStepViewModel)Activator.CreateInstance(t))
                .ToList();
        }
    }

    [Serializable]
    public class Step1ViewModel : IStepViewModel
    {
        [Required]
        public string Foo { get; set; }
    }

    [Serializable]
    public class Step2ViewModel : IStepViewModel
    {
        public string Bar { get; set; }
    }

    [Serializable]
    public class Step3ViewModel : IStepViewModel
    {
        [Required]
        public string Baz { get; set; }
    }

    public interface IStepViewModel
    {
    }

    //Look for alternates of DefaultModelBinder like here: https://stackoverflow.com/questions/7025170/how-to-bind-a-model-property-with-defaultmodelbinder-asp-net-mvc2?rq=1 (right answer)
    //public class StepViewModelBinder : DefaultModelBinder
    //{
    //    protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
    //    {
    //        var stepTypeValue = bindingContext.ValueProvider.GetValue("StepType");
    //        var stepType = Type.GetType((string)stepTypeValue.ConvertTo(typeof(string)), true);
    //        var step = Activator.CreateInstance(stepType);
    //        bindingContext.ModelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => step, stepType);
    //        return step;
    //    }
    //}
}
