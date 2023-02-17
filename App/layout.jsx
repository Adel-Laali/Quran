import { useLayout } from 'Base'

const Layout = ({ children }) => {

    return useLayout().render(<>
        {children}
    </>)
}

export default Layout
