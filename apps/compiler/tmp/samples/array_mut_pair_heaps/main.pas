program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TSpiralRc = class refc: LongInt; procedure DropFields; virtual; end;
  TMut1 = class;
  TBoxArray0 = class;
  THeap0 = record l0: LongInt; l1: AnsiString; end;
  TMut1 = class(TSpiralRc) l0: THeap0; l1: THeap0; end;
  TBoxArray0 = class(TSpiralRc) items: array of TMut1; procedure DropFields; override; end;
procedure TSpiralRc.DropFields;
begin
end;
procedure SpiralRetain(o: TSpiralRc);
begin
  if o <> nil then Inc(o.refc);
end;
procedure SpiralRelease(o: TSpiralRc);
begin
  if o <> nil then begin Dec(o.refc); if o.refc < 0 then begin o.DropFields; o.Free; end; end;
end;
function SpiralKeep(o: TSpiralRc): TSpiralRc;
begin
  SpiralRetain(o); Result := o;
end;
function HeapCreate0(a0: LongInt; a1: AnsiString): THeap0;
begin
  Result.l0 := a0; Result.l1 := a1;
end;
function MutCreate1(a0: THeap0; a1: THeap0): TMut1;
begin
  Result := TMut1.Create; Result.l0 := a0; Result.l1 := a1;
end;
procedure TBoxArray0.DropFields;
var i: Int64;
begin
  for i := 0 to High(items) do begin SpiralRelease(items[i]); end;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: AnsiString;
  v2: THeap0;
  v3: LongInt;
  v4: AnsiString;
  v5: THeap0;
  v6: TMut1;
  v7: TBoxArray0;
  tmp8: TBoxArray0;
  v8: LongInt;
  v9: AnsiString;
  v10: THeap0;
  v11: LongInt;
  v12: AnsiString;
  v13: THeap0;
  v14: TMut1;
  v15: THeap0;
  v16: THeap0;
  v17: LongInt;
  v18: AnsiString;
  v19: LongInt;
  v20: AnsiString;
  v21: Boolean;
  v23: Boolean;
  v22: Boolean;
  v25: Boolean;
  v24: Boolean;
  v27: Boolean;
  v26: Boolean;
begin
  v0 := 1;
  v1 := 'no';
  v2 := HeapCreate0(v0, v1);
  v3 := 2;
  v4 := 'zz';
  v5 := HeapCreate0(v3, v4);
  v6 := MutCreate1(v2, v5);
  tmp8 := TBoxArray0.Create;
  SetLength(tmp8.items, 1);
  v7 := tmp8;
  SpiralRetain(v6); SpiralRelease(v7.items[0]); v7.items[0] := v6;
  SpiralRelease(v6);
  v8 := 7;
  v9 := 'hi';
  v10 := HeapCreate0(v8, v9);
  v11 := 4;
  v12 := 'yo';
  v13 := HeapCreate0(v11, v12);
  v14 := v7.items[0];
  SpiralRetain(v14);
  SpiralRelease(v7);
  v14.l0 := v10;
  v14.l1 := v13;
  v15 := v14.l0;
  v16 := v14.l1;
  SpiralRelease(v14);
  v17 := v15.l0;
  v18 := v15.l1;
  v19 := v16.l0;
  v20 := v16.l1;
  v21 := v17 = 7;
  if v21 then begin
      v22 := v18 = 'hi';
      v23 := v22;
  end else begin
      v23 := False;
  end;
  if v23 then begin
      v24 := v19 = 4;
      v25 := v24;
  end else begin
      v25 := False;
  end;
  if v25 then begin
      v26 := v20 = 'yo';
      v27 := v26;
  end else begin
      v27 := False;
  end;
  if v27 then begin
      Result := 0;
  end else begin
      Result := 1;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
