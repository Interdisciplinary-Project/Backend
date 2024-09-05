import { string } from 'prop-types';
import { Link, useLocation } from 'react-router-dom';

function AnimatedLink({ to = '#', text }) {
  const location = useLocation();

  const isActive = location.pathname === to;

  return (
    <Link
      className={`
        no-underline text-social-black font-medium relative hover:before:w-3/4
        before:transition-all before:duration-500 before:ease-[cubic-bezier(0.68,-0.55,0.27,1.55)]
        before:content-[''] before:inline-block before:absolute before:bottom-0
        before:h-[2px] before:w-0
        ${isActive ? 'text-social-brand before:bg-social-brand before:w-3/4' : 'before:bg-social-black'}
      `}
      to={to}
      target="_self"
      rel="next noopener noreferrer follow"
    >
      {text}
    </Link>
  );
}

AnimatedLink.propTypes = {
  to: string,
  text: string,
};

export { AnimatedLink };
