import { initializeApp } from 'firebase/app';
import { getAnalytics } from 'firebase/analytics';
import { getAuth } from 'firebase/auth';
import { ReCaptchaV3Provider, initializeAppCheck } from 'firebase/app-check';

const firebaseConfig = {
  apiKey: import.meta.env.VITE_FIREBASE_API_KEY,
  authDomain: import.meta.env.VITE_AUTH_DOMAIN,
  projectId: import.meta.env.VITE_PROJECT_ID,
  storageBucket: import.meta.env.VITE_STORAGE_BUCKET,
  messagingSenderId: import.meta.env.VITE_MESSAGING_SENDER_IR,
  appId: import.meta.env.VITE_API_ID,
  measurementId: import.meta.env.VITE_MEASUREMENT_ID,
};

const app = initializeApp(firebaseConfig);
const analytics = getAnalytics(app);
const auth = getAuth(app);
const appCheck = initializeAppCheck(app, {
  provider: new ReCaptchaV3Provider('AIzaSyDd7dkLNZS-4r2jtXWQfWzTNIRAJvOmnmA'),
  isTokenAutoRefreshEnabled: true
});

export { appCheck, app, analytics, auth };
