import { profileData } from '../../../features/profile/profile.data.ts';

export default function StackGrid() {
  return (
    <section className="stack">
      <h2>🧰 My Tech Stack</h2>
      <div className="stack-grid">
        {profileData.stack.map((tech) => (
          <span key={tech} className="stack-item">
            {tech}
          </span>
        ))}
      </div>
    </section>
  );
}
