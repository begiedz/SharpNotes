import { serverUrl } from '@/lib/config';
import { apiFetch } from '@/lib/api';
import type { Note } from '@/types/note';

export async function fetchNotes(): Promise<Note[]> {
  return apiFetch<Note[]>(`${serverUrl}/notes`);
}
