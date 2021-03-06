using System;
using Unity.UIWidgets.foundation;
using Unity.UIWidgets.painting;

namespace Unity.UIWidgets.widgets {
    public class SafeArea : StatelessWidget {
        public SafeArea(
            Key key = null,
            bool left = true,
            bool top = true,
            bool right = true,
            bool bottom = true,
            EdgeInsets mininum = null,
            Widget child = null
        ) : base(key: key) {
            D.assert(child != null);
            this.left = left;
            this.top = top;
            this.right = right;
            this.bottom = bottom;
            this.minimum = mininum ?? EdgeInsets.zero;
            this.child = child;
        }

        public readonly bool left;

        public readonly bool top;

        public readonly bool right;

        public readonly bool bottom;

        public readonly EdgeInsets minimum;

        public readonly Widget child;

        public override Widget build(BuildContext context) {
            EdgeInsets padding = MediaQuery.of(context).padding;
            return new Padding(
                padding: EdgeInsets.only(
                    left: Math.Max(this.left ? padding.left : 0.0, this.minimum.left),
                    top: Math.Max(this.top ? padding.top : 0.0, this.minimum.top),
                    right: Math.Max(this.right ? padding.right : 0.0, this.minimum.right),
                    bottom: Math.Max(this.bottom ? padding.bottom : 0.0, this.minimum.bottom)
                ),
                child: MediaQuery.removePadding(
                    context: context,
                    removeLeft: this.left,
                    removeTop: this.top,
                    removeRight: this.right,
                    removeBottom: this.bottom,
                    child: this.child));
        }


        public override void debugFillProperties(DiagnosticPropertiesBuilder properties) {
            base.debugFillProperties(properties);
            properties.add(new FlagProperty("left", value: this.left, ifTrue: "avoid left padding"));
            properties.add(new FlagProperty("top", value: this.top, ifTrue: "avoid top padding"));
            properties.add(new FlagProperty("right", value: this.right, ifTrue: "avoid right padding"));
            properties.add(new FlagProperty("bottom", value: this.bottom, ifTrue: "avoid bottom padding"));
        }
    }
}