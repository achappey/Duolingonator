import { INavLinkGroup, Nav } from "@fluentui/react"
import { useLocation } from "react-router";

const navLinkGroups: INavLinkGroup[] = [
    {
        links: [
            {
                name: 'Home',
                url: '/',
                icon: 'Home',
                key: '/'
            },
            {
                name: 'API Key',
                url: '/access',
                icon: 'Settings',
                key: '/access'
            },
            {
                name: 'Swagger',
                url: '/swagger',
                key: '/swagger',
                icon: 'Code',
                target: '_blank',
            }
        ],
    },
];

export const SideNavigation: React.FunctionComponent = () => {
    const { pathname } = useLocation();

    return <Nav
        selectedKey={pathname}
        groups={navLinkGroups}
    />
}