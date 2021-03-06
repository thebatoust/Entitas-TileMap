namespace Entitas {
    public partial class Entity {
        public TilePositionComponent tilePosition { get { return (TilePositionComponent)GetComponent(ComponentIds.TilePosition); } }

        public bool hasTilePosition { get { return HasComponent(ComponentIds.TilePosition); } }

        public Entity AddTilePosition(Hex newPosition) {
            var componentPool = GetComponentPool(ComponentIds.TilePosition);
            var component = (TilePositionComponent)(componentPool.Count > 0 ? componentPool.Pop() : new TilePositionComponent());
            component.position = newPosition;
            return AddComponent(ComponentIds.TilePosition, component);
        }

        public Entity ReplaceTilePosition(Hex newPosition) {
            var componentPool = GetComponentPool(ComponentIds.TilePosition);
            var component = (TilePositionComponent)(componentPool.Count > 0 ? componentPool.Pop() : new TilePositionComponent());
            component.position = newPosition;
            ReplaceComponent(ComponentIds.TilePosition, component);
            return this;
        }

        public Entity RemoveTilePosition() {
            return RemoveComponent(ComponentIds.TilePosition);;
        }
    }

    public partial class Matcher {
        static IMatcher _matcherTilePosition;

        public static IMatcher TilePosition {
            get {
                if (_matcherTilePosition == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.TilePosition);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherTilePosition = matcher;
                }

                return _matcherTilePosition;
            }
        }
    }
}
