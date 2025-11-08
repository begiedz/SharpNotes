'use client';
import { useEffect, useState } from 'react';
import type { Note } from '@/types/note';
import { fetchNotes } from '@/services/notes';
export default function Home() {
  const [notes, setNotes] = useState<Note[]>([]);

  useEffect(() => {
    fetchNotes()
      .then(setNotes)
      .catch(err => console.error('fetch error', err));
  }, []);

  return (
    <main>
      <h1 className="font-bold text-4xl">SharpNotes</h1>
      <ul className="my-8">
        {notes.map(note => (
          <li
            key={note.id}
            className="my-2"
          >
            <strong>{note.title}</strong>
            <p>{note.content}</p>
          </li>
        ))}
      </ul>
    </main>
  );
}
