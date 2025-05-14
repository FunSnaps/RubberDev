import Hero from '../molecules/Hero';
import StackGrid from '../molecules/StackGrid';
import ProjectIntro from '../molecules/ProjectIntro';
import Contact from '../molecules/Contact';

export default function ProfilePage() {
  return (
    <div className="profile-page">
      {/* Hero banner */}
      <Hero />

      {/* Tech stack card */}
      <section className="section-card">
        <StackGrid />
      </section>

      {/* Projects + Contact in one card */}
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
