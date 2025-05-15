import Text from '../atoms/Text';

interface FilterProps {
  search: string;
  onSearchChange: (value: string) => void;
}

export default function FilterControls({
  search,
  onSearchChange,
}: FilterProps) {
  return (
    <div className="filter-controls">
      <Text as="label">🔍 Search:</Text>
      <input
        type="text"
        value={search}
        onChange={(e) => onSearchChange(e.target.value)}
        placeholder="Search characters..."
      />
    </div>
  );
}
