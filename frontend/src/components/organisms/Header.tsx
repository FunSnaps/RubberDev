import { NavLink } from 'react-router-dom';
import Text from '../atoms/Text';

export default function Header() {
  return (
    <header className="site-header">
      <nav>
        <NavLink to="/" end>
          <Text as="span">Home</Text>
        </NavLink>
        <NavLink to="/game">
          <Text as="span">Game</Text>
        </NavLink>
      </nav>
    </header>
  );
}
