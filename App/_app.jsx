import Head from 'next/head';
import '../styles/all.scss';

function MyApp({ Component, pageProps }) {
    return (
        <>
            <Head>
                <title>{process.env.NEXT_PUBLIC_BRAND} - {process.env.NEXT_PUBLIC_SLOGAN}</title>
                <link rel="icon" href="/images/favicon.ico" />
            </Head>
            <Component {...pageProps} />
        </>
    );
}

export default MyApp