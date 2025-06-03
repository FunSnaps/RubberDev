import * as React from 'react';

type ButtonProps = {
  children: React.ReactNode;
  onClick?: () => void;
  className?: string;
  type?: 'button' | 'submit' | 'reset';
  variant?: 'primary' | 'danger';
};

export default function Button({
  children,
  onClick,
  className = '',
  type = 'button',
  variant = 'primary',
}: ButtonProps) {
  const variantClass = variant ? `button--${variant}` : '';
  return (
    <button
      onClick={onClick}
      className={`button ${variantClass} ${className}`}
      type={type}
    >
      {children}
    </button>
  );
}
