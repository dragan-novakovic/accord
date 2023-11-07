/* eslint-disable @typescript-eslint/no-explicit-any */

import { writable, type Writable } from 'svelte/store'

import type { Handle, RequestEvent } from '@sveltejs/kit'
import { query } from '$lib/server/db'

// Attach authorization to each server request (role may have changed)
async function attachUserToRequestEvent(sessionId: string, event: RequestEvent) {
  const sql = `
    SELECT * FROM get_session($1);`
  const { rows } = await query(sql, [sessionId])
  if (rows?.length > 0) {
    event.locals.user = <User> rows[0].get_session
  }
}

// Invoked for each endpoint called and initially for SSR router
export const handle: Handle = async ({ event, resolve }) => {
  const { cookies } = event
  const sessionId = cookies.get('session')

  // before endpoint or page is called
  if (sessionId) {
    await attachUserToRequestEvent(sessionId, event)
  }

  if (!event.locals.user) cookies.delete('session')

  const response = await resolve(event)

  // after endpoint or page is called

  return response
}


  async function loginLocal(credentials: Credentials) {
		try {
			const res = await fetch('/auth/login', {
				method: 'POST',
				body: JSON.stringify(credentials),
				headers: {
					'Content-Type': 'application/json'
				}
			})
			const fromEndpoint = await res.json()
			if (res.ok) {
				loginSession.set(fromEndpoint.user)
				const { role } = fromEndpoint.user
        const referrer = $page.url.searchParams.get('referrer')
				if (referrer) return goto(referrer)
				if (role === 'teacher') return goto('/teachers')
				if (role === 'admin') return goto('/admin')
				return goto('/')
			} else {
				throw new Error(fromEndpoint.message)
			}
		} catch (err) {
			if (err instanceof Error) {
				console.error('Login error', err)
				throw new Error(err.message)
			}
		}
	}

// See https://kit.svelte.dev/docs/types#app
// for information about these interfaces
// and what to do when importing types
declare namespace App {
	interface Locals {
    user: User
  }

	// interface Platform {}

  interface PrivateEnv { // $env/static/private
    DATABASE_URL: string
    DOMAIN: string
    JWT_SECRET: string
    SENDGRID_KEY: string
    SENDGRID_SENDER: string
  } 

	interface PublicEnv { // $env/static/public
    PUBLIC_GOOGLE_CLIENT_ID: string
  }
}

interface AuthenticationResult {
  statusCode: number
  status: string
  user: User
  sessionId: string
}

interface Credentials {
  email: string
  password: string
}

interface UserProperties {
  id: number
  expires?: string // ISO-8601 datetime
  role: 'student' | 'teacher' | 'admin'
  password?: string
  firstName?: string
  lastName?: string
  email?: string
  phone?: string
}

type User = UserProperties | undefined | null

interface UserSession {
  id: string,
  user: User
}


export const toast = writable({
	title: '',
	body: '',
	isOpen: false
})

// While server determines whether the user is logged in by examining RequestEvent.locals.user, the
// loginSession is updated so all parts of the SPA client-side see the user and role.
export const loginSession = <Writable<User>> writable(undefined)

export const googleInitialized = writable(false)