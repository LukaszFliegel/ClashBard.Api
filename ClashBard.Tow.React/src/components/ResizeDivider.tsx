import { useCallback, useRef } from 'react';
import { useTheme } from '../contexts/ThemeContext';

interface Props {
  direction?: 'vertical';
  onResizeEnd?: (prevPercent: number, nextPercent: number) => void;
}

export default function ResizeDivider({ direction: _, onResizeEnd }: Props) {
  const ref = useRef<HTMLDivElement>(null);
  const { mode } = useTheme();

  const onMouseDown = useCallback(
    (e: React.MouseEvent) => {
      e.preventDefault();
      const divider = ref.current;
      if (!divider) return;

      const prev = divider.previousElementSibling as HTMLElement | null;
      const next = divider.nextElementSibling as HTMLElement | null;
      if (!prev || !next) return;

      const startX = e.clientX;
      const prevWidth = prev.getBoundingClientRect().width;
      const nextWidth = next.getBoundingClientRect().width;

      function onMouseMove(ev: MouseEvent) {
        const dx = ev.clientX - startX;
        const newPrev = Math.max(200, prevWidth + dx);
        const newNext = Math.max(200, nextWidth - dx);
        prev!.style.width = `${newPrev}px`;
        prev!.style.minWidth = `${newPrev}px`;
        prev!.style.flex = 'none';
        next!.style.width = `${newNext}px`;
        next!.style.minWidth = `${newNext}px`;
        next!.style.flex = 'none';
      }

      function onMouseUp() {
        document.removeEventListener('mousemove', onMouseMove);
        document.removeEventListener('mouseup', onMouseUp);
        document.body.style.cursor = '';
        document.body.style.userSelect = '';

        if (onResizeEnd) {
          const container = divider!.parentElement;
          if (container) {
            const totalWidth = container.getBoundingClientRect().width;
            if (totalWidth > 0) {
              const prevFinalWidth = prev!.getBoundingClientRect().width;
              const nextFinalWidth = next!.getBoundingClientRect().width;
              onResizeEnd(
                (prevFinalWidth / totalWidth) * 100,
                (nextFinalWidth / totalWidth) * 100,
              );
            }
          }
        }
      }

      document.body.style.cursor = 'col-resize';
      document.body.style.userSelect = 'none';
      document.addEventListener('mousemove', onMouseMove);
      document.addEventListener('mouseup', onMouseUp);
    },
    [onResizeEnd],
  );

  const borderColor =
    mode === 'dark' ? 'rgba(255,255,255,0.12)' : 'rgba(0,0,0,0.12)';
  const hoverBg =
    mode === 'dark' ? 'rgba(255,255,255,0.08)' : 'rgba(0,0,0,0.06)';

  return (
    <div
      ref={ref}
      onMouseDown={onMouseDown}
      style={{
        width: 6,
        minWidth: 6,
        cursor: 'col-resize',
        background: borderColor,
        transition: 'background 0.2s',
        flexShrink: 0,
      }}
      onMouseEnter={(e) => {
        (e.currentTarget as HTMLElement).style.background = hoverBg;
      }}
      onMouseLeave={(e) => {
        (e.currentTarget as HTMLElement).style.background = borderColor;
      }}
    />
  );
}

