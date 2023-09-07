import { sveltekit } from '@sveltejs/kit/vite';
import type { UserConfig } from 'vite';

const config: UserConfig = {
	server: {
		watch: {
			usePolling: true
		},
		host: '0.0.0.0',
		hmr: {
			port: 3101
		}
	},
	plugins: [sveltekit()]
};

export default config;
