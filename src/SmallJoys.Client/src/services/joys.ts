import { serverUrl } from '@/lib/config';
import { apiFetch } from '@/lib/api';
import type { Joy } from '@/types/joy';

export async function fetchJoys(): Promise<Joy[]> {
  return apiFetch<Joy[]>(`${serverUrl}/joys`);
}
