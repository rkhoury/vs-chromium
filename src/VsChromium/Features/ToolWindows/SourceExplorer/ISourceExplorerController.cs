﻿// Copyright 2014 The Chromium Authors. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

using Microsoft.VisualStudio.Text;
using VsChromium.Core.Files;
using VsChromium.Core.Ipc;
using VsChromium.Core.Ipc.TypedMessages;
using VsChromium.Settings;
using VsChromium.Threads;
using VsChromium.Views;
using VsChromium.Wpf;

namespace VsChromium.Features.ToolWindows.SourceExplorer {
  /// <summary>
  /// Exposes services required by <see cref="SourceExplorerItemViewModelBase"/> instances.
  /// </summary>
  public interface ISourceExplorerController {
    IUIRequestProcessor UIRequestProcessor { get; }
    IStandarImageSourceFactory StandarImageSourceFactory { get; }
    IClipboard Clipboard { get; }
    IWindowsExplorer WindowsExplorer { get; }
    GlobalSettings Settings { get; }

    void RefreshFileSystemTree();
    void SetFileSystemTree(FileSystemTree tree);
    void FilesLoaded();

    void SearchText(string searchPattern, string fileNamePattern, bool immediate);
    void SearchFilesNames(string searchPattern, bool immediate);

    void SetFileSystemTreeError(ErrorResponse error);

    void OpenFileInEditor(FileEntryViewModel fileEntry, Span? span);
    void ShowInSourceExplorer(FileSystemEntryViewModel relativePathEntry);
    void BringItemViewModelToView(TreeViewItemViewModel item);
    bool ExecuteOpenCommandForItem(TreeViewItemViewModel item);

    // Search result navigation
    bool HasNextLocation();
    bool HasPreviousLocation();
    void NavigateToNextLocation();
    void NavigateToPreviousLocation();
    void CancelSearch();
  }
}