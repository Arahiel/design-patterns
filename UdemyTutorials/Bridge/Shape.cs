namespace Bridge
{
    public abstract class Shape
    {
        private readonly IRenderer _renderer;

        protected Shape(IRenderer renderer)
        {
            _renderer = renderer;
        }

        public string Name { get; set; }

        public override string ToString() => $"Drawing {Name} as {_renderer.WhatToRenderAs}";
    }
}