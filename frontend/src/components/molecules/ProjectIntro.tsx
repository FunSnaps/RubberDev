import Text from '../atoms/Text';

export default function ProjectIntro() {
  return (
    <section className="projects">
      <Text as="h2">🚀 Featured Project: RubberDev</Text>
      <Text as="p">
        RubberDev is a cartoon character collector game built with full RESTful
        backend, atomic design, and clean architecture.
      </Text>
    </section>
  );
}
