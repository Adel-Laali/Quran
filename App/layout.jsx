import '../Styles/All.scss'
import { useLayout } from 'Base'

function Layout({ children }) {

    return useLayout({
        head: <></>,
    }).render(<>
        {children}
    </>)
}

export default Layout
