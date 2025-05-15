import * as React from 'react';

type TextProps = {
  children: React.ReactNode;
  as?: 'p' | 'span' | 'strong' | 'h1' | 'h2' | 'h3' | 'label';
  className?: string;
};

export default function Text({
  children,
  as = 'p',
  className = '',
}: TextProps) {
  const Component = as;
  return <Component className={className}>{children}</Component>;
}
