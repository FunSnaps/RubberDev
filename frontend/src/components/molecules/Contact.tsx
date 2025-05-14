import Text from '../atoms/Text';
import { profileData } from '../../features/profile/profile.data';

export default function Contact() {
  return (
    <section className="contact">
      <Text as="h2">📬 Let’s Connect</Text>
      <Text as="p">
        GitHub:{' '}
        <a href={profileData.github} target="_blank">
          {profileData.github}
        </a>
      </Text>
      <Text as="p">
        Email: <a href={`mailto:${profileData.email}`}>{profileData.email}</a>
      </Text>
    </section>
  );
}
