﻿using TagsCloudContainer.Common;
using TagsCloudContainer.Common.Result;
using TagsCloudContainer.Preprocessors;

namespace TagsCloudContainer.UI
{
    public class GetAllPreprocessorsAction : UiAction
    {
        public override string Category => "Preprocessors";
        public override string Name => "GetAllPreprocessors";
        public override string Description => "";

        public GetAllPreprocessorsAction(IResultHandler handler)
            : base(handler)
        {
        }

        protected override void PerformAction()
        {
            var preprocessors = TagsPreprocessor.AllPreprocessors;
            foreach (var p in preprocessors)
            {
                var prop = p.GetProperty(nameof(State));
                var status = (State) prop.GetValue(null);
                handler.AddHandledText($@"{p.Name} is {status}");
            }
        }
    }
}