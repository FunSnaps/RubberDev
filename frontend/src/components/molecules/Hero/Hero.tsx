import Text from '../../atoms/Text/Text.tsx';
import { profileData } from '../../../features/profile/profile.data.ts';

export default function Hero() {
  return (
    <section className="hero">
      <Text as="h1">👋 Hi, I'm {profileData.name}</Text>
      <Text as="p">{profileData.tagline}</Text>
    </section>
  );
}
