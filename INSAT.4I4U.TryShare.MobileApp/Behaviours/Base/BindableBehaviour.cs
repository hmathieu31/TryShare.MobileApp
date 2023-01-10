using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INSAT._4I4U.TryShare.MobileApp.Behaviours.Base
{
    public class BindableBehaviour<T> : Behavior<T> where T : BindableObject
    {
        public T AssociatedObject { get; private set; }

        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);

            AssociatedObject = bindable as T;

            if (AssociatedObject is not null)
                BindingContext = bindable.BindingContext;

            bindable.BindingContextChanged += Bindable_BindingContextChanged;
        }

        private void Bindable_BindingContextChanged(object sender, EventArgs e)
        {
            OnBindingContextChanged();
        }

        protected override void OnDetachingFrom(T bindable)
        {
            base.OnDetachingFrom(bindable);

            bindable.BindingContextChanged -= Bindable_BindingContextChanged;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            BindingContext = AssociatedObject.BindingContext;
        }
    }
}
