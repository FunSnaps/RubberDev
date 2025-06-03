import ProjectIntro from '../../molecules/ProjectIntro/ProjectIntro.tsx';
import Hero from '../../molecules/Hero/Hero.tsx';
import StackGrid from '../../molecules/StackGrid/StackGrid.tsx';
import Contact from '../../molecules/Contact/Contact.tsx';

export default function ProfilePage() {
  return (
    <div className="profile-page">
      <Hero />
      <section className="section-card">
        <StackGrid />
      </section>
      <section className="section-card two-column">
        <div className="col">
          <ProjectIntro />
        </div>
        <div className="col">
          <Contact />
        </div>
      </section>
    </div>
  );
}
