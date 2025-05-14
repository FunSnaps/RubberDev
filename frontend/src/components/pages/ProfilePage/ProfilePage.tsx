import Hero from '../../molecules/Hero.tsx';
import StackGrid from '../../molecules/StackGrid.tsx';
import ProjectIntro from '../../molecules/ProjectIntro.tsx';
import Contact from '../../molecules/Contact.tsx';

export default function ProfilePage() {
  return (
    <div className="profile-page">
      <Hero />
      <StackGrid />
      <ProjectIntro />
      <Contact />
    </div>
  );
}
